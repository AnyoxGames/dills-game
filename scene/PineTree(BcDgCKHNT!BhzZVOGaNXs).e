13
3320009719809
404860833395539 1761863288643704300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -9.7214221954345703,
    "Y": 9.6212701797485352
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404859259782631:1761863288277050900",
  "next_sibling": "404862478590829:1761863289027036300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404860833642058:1761863288643760700",
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
  "aoid": "404860833767833:1761863288643790000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404860833642058:1761863288643760700",
    "DefaultRenderer": "404860833818917:1761863288643801900",
    "DepletedRenderer": "404860833801287:1761863288643797800"
  }
},
{
  "cid": 5,
  "aoid": "404860833780346:1761863288643792900",
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
