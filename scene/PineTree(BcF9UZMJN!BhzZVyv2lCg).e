13
4436701216769
405029716804173 1761863327993712800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 8.3868007659912109,
    "Y": -10.7531461715698242
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405025353449472:1761863326977046900",
  "next_sibling": "405031005242735:1761863328293921100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405029717046521:1761863327993768700",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "405029717165717:1761863327993796500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405029717046521:1761863327993768700",
    "DefaultRenderer": "405029717217833:1761863327993808600",
    "DepletedRenderer": "405029717199214:1761863327993804300"
  }
},
{
  "cid": 5,
  "aoid": "405029717179434:1761863327993799700",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
