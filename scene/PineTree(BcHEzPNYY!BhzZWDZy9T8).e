13
4909147619329
405106469951000 1761863345877275900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 15.6036663055419922,
    "Y": -2.2892887592315674
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405104967613169:1761863345527229900",
  "next_sibling": "405110904438914:1761863346910515900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405106470316930:1761863345877360200",
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
  "aoid": "405106470471472:1761863345877396200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405106470316930:1761863345877360200",
    "DefaultRenderer": "405106470526125:1761863345877408900",
    "DepletedRenderer": "405106470510215:1761863345877405200"
  }
},
{
  "cid": 5,
  "aoid": "405106470490564:1761863345877400600",
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
