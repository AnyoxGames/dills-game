13
4458176053249
405031005242735 1761863328293921100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 10.0116252899169922,
    "Y": -10.3255615234375000
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405029716804173:1761863327993712800",
  "next_sibling": "405032364293167:1761863328610581100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405031005639754:1761863328294012300",
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
  "aoid": "405031005793350:1761863328294048100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405031005639754:1761863328294012300",
    "DefaultRenderer": "405031005876512:1761863328294067500",
    "DepletedRenderer": "405031005849766:1761863328294061200"
  }
},
{
  "cid": 5,
  "aoid": "405031005817086:1761863328294053600",
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
